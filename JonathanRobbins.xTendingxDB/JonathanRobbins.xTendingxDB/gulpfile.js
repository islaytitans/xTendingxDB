// gulp require modules
var gulp = require('gulp');
var watch = require('gulp-watch');
var runSequence = require('run-sequence');

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

gulp.task('default', function () {
    gulp.watch('./src/less/**/*.less', function() {       
        runSequence('less', 'copy');
    });
});

gulp.task('copy', function () {
    return gulp.src([
      './dist/css/*.css',
      './dist/scripts/*.js'
    ], { base: './' })
  .pipe(gulp.dest('C:/inetpub/wwwroot/xTendingxDB/Website'));
});