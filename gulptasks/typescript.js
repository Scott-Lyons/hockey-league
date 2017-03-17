var gulp = require('gulp'),
    tsc = require('gulp-typescript'),
    sourcemaps = require('gulp-sourcemaps'),
	config = require('../config');
    
gulp.task('ts-compile', function(){
    var tsProject = tsc.createProject("./tsconfig.json");
	
	var tsResult = tsProject.src()
		.pipe(sourcemaps.init())
		.pipe(tsc(tsProject))
		
	return tsResult.js
		.pipe(sourcemaps.write('.'))
		.pipe(gulp.dest('.'));
});

gulp.task('ts-watch', function(){
	gulp.watch(config.web_app_path + "/**/*.ts", ['ts-compile']);
})