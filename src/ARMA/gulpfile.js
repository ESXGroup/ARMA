var gulp = require("gulp");
var tsConfig = require("tsconfig-glob");

gulp.task("tsconfig-glob", function () {
    return tsConfig({
        configPath: ".",
        cwd: process.cwd(),
        indent: 2
    });
});

gulp.task('copy-typings', function () {
    return gulp.src('jspm_packages/**/*.d.ts')
    .pipe(gulp.dest('app/typings'));
});

gulp.task("watch", function () {
    var tsConfigFile = require("./tsconfig.json");
    gulp.watch(tsConfigFile.filesGlob, ["tsconfig-glob"]).on("change", reportChange);
   // gulp.watch("jspm_packages/**/*.d.ts", ["copy-typings"]).on("change", reportChange);
});

function reportChange(event) {
    console.log("File " + event.path + " was " + event.type + ", running tasks...");
}