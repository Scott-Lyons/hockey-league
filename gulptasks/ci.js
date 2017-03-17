var gulp = require('gulp'),
    runSequence = require('run-sequence');
    
gulp.task('ci', function(done) {
    runSequence('build', 'copy-js', 'copy-html', 'compress', done);
});