/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        bower: {
            install: {
                options: {
                    targetDir: "wwwroot/lib",
                    layout: "byComponent",
                    cleanTargetDir: false
                }
            }
        },
        sass: {
            dist: {
                options: {
                    style: 'compressed'
                },
                files: [
                  {
                      expand: true,
                      cwd: 'scss',
                      src: ["*.scss"],
                      dest: "css",
                      ext: ".min.css"
                  }
                ]
            }
        },
        watch: {
            sass: {
                files: ["**/*.scss"],
                tasks: ["sass"],
                options: {
                    livereload: true
                }
            }
        }
    });

    grunt.registerTask("default", ["bower:install"]);

    grunt.loadNpmTasks("grunt-bower-task");
    grunt.loadNpmTasks("grunt-contrib-watch");
    grunt.loadNpmTasks("grunt-contrib-sass");
};