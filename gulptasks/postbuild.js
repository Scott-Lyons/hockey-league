var gulp = require('gulp'),
    runSequence = require('run-sequence');
    
gulp.task('postbuild', function(done) {
    runSequence('ts-compile', 'copy-files', done);
});
