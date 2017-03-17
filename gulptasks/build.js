var gulp = require('gulp'),
    msbuild = require('gulp-msbuild'),
    config = require('../config'),
    gutil = require('gutil');
    
gulp.task("build", function(){   
   return gulp.src(config.solution_path)
            .pipe(msbuild({
                targets: ['Clean', 'Build'],
                stdout: true
            })); 
});