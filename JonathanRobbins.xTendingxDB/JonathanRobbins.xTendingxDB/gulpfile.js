// gulp require modules
var gulp = require('gulp');

// less modules 
var less = require('gulp-less');
var path = require('path'); // @include path


gulp.task('less', function () {
    return gulp.src('./src/less/*.less')
    .pipe(less({
        paths: [path.join(__dirname, 'less', 'modules', 'core')]
    }))
    .pipe(gulp.dest('./dist/css'));
});

