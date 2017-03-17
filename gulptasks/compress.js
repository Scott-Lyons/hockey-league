var gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    gutil = require('gutil'),
    config = require('../config');
    
gulp.task('compress', function(){
    gutil.log(config.build_web_path + '/**/*.js');
   return gulp.src(config.build_web_path + '/**/*.js')
            .pipe(uglify())
            .pipe(gulp.dest(config.build_web_path)); 
});