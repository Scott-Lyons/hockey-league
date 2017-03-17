var gulp = require('gulp'),
    runSequence = require('run-sequence'),
    config = require('../config'),
    argv = require('yargs').argv;;

var buildPath = "";
if(argv.configuration){
    buildPath = config.build_web_path.replace("{Configuration}", argv.configuration);
} else if (config.build_web_path.indexOf("{Configuration}") > -1) {
    buildPath = config.build_web_path.replace("{Configuration}", "Debug");
} else {
    buildPath = config.build_web_path;
}


gulp.task('copy-files', function(done) {
    runSequence('build', 'copy-js', 'copy-html', 'copy-css', done);
});

gulp.task('copy-css', function(){
    gulp.src([config.web_path + '/**/*.css', 
              '!' + config.web_path + '/**/bin/**/*.css'], {base: config.web_path})
        .pipe(gulp.dest(buildPath))
});

gulp.task('copy-html', function(){
    gulp.src([config.web_path + '/**/*.html', 
              '!' + config.web_path + '/**/bin/**/*.html'], {base: config.web_path})
        .pipe(gulp.dest(buildPath))
});

gulp.task('copy-js', function(){
    gulp.src([config.web_path + '/**/*.js', 
              '!' + config.web_path + '/**/bin/**/*.js'], {base: config.web_path})
        .pipe(gulp.dest(buildPath))
});