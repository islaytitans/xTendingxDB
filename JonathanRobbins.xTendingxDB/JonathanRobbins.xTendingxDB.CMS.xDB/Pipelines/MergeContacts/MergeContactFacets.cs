using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.xDB.Facets;
using Sitecore.Analytics.Model.Framework;
using Sitecore.Analytics.Pipelines.MergeContacts;
using Sitecore.Diagnostics;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Pipelines.MergeContacts
{
    public class MergeContactFacets : MergeContactProcessor
    {
        public override void Process(MergeContactArgs args)
        {
            Assert.ArgumentNotNull((object) args, "args");
            foreach (string name in args.DyingContact.Facets.Keys)
            {
                IFacet source = args.DyingContact.Facets[name];
                IFacet destination = (IFacet) null;
                try
                {
                    destination = args.SurvivingContact.GetFacet<IFacet>(name);
                }
                catch (FacetNotAvailableException ex)
                {
                    Log.Error(ex.Message, ex, this);
                }
                // Check if the name of the Facet is the name of our custom Facet
                if (name.Equals(KeyInteractionsFacet.FacetName, StringComparison.InvariantCultureIgnoreCase) && destination != null && !source.IsEmpty)
                {
                    DeepCopyFacet(source, destination);
                }
                else if (destination != null && destination.IsEmpty && !source.IsEmpty)
                {
                    ModelUtilities.DeepCopyFacet(source, destination);
                }
            }
        }

        public static void DeepCopyFacet(IFacet source, IFacet destination)
        {
            Assert.ArgumentNotNull((object)source, "source");
            Assert.ArgumentNotNull((object)destination, "destination");
            CopyElement((IElement)source, (IElement)destination);
        }

        private static void CopyElement(IElement source, IElement destination)
        {
            foreach (IModelMember modelMember in (IEnumerable<IModelMember>)source.Members)
            {
                IModelAttributeMember modelAttributeMember = modelMember as IModelAttributeMember;
                if (modelAttributeMember != null)
                {
                    ((IModelAttributeMember)destination.Members[modelMember.Name]).Value
                        = modelAttributeMember.Value;
                }
                else
                {
                    IModelDictionaryMember dictionaryMember1 = modelMember as IModelDictionaryMember;
                    if (dictionaryMember1 != null)
                    {
                        IModelDictionaryMember dictionaryMember2
                            = (IModelDictionaryMember)destination.Members[modelMember.Name];

                        foreach (string key in (IEnumerable<string>)dictionaryMember1.Elements.Keys)
                        {
                            IElement destination1 = dictionaryMember2.Elements.Create(key);
                            CopyElement(dictionaryMember1.Elements[key], destination1);
                        }
                    }
                    else
                    {
                        IModelCollectionMember collectionMember1 = modelMember as IModelCollectionMember;
                        if (collectionMember1 != null)
                        {
                            IModelCollectionMember collectionMember2
                                = (IModelCollectionMember)destination.Members[modelMember.Name];

                            for (int index = 0; index < collectionMember1.Elements.Count; ++index)
                            {
                                IElement destination1 = collectionMember2.Elements.Create();
                                CopyElement(collectionMember1.Elements[index], destination1);
                            }
                        }
                        else
                        {
                            IModelElementMember modelElementMember1 = modelMember as IModelElementMember;
                            if (modelElementMember1 != null)
                            {
                                IModelElementMember modelElementMember2
                                    = (IModelElementMember)destination.Members[modelElementMember1.Name];
                                CopyElement(modelElementMember1.Element, modelElementMember2.Element);
                            }
                        }
                    }
                }
            }
        }
    }
}