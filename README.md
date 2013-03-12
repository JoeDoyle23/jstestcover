jstestcover
========

.NET JavaScript Code Coverage tool

This is a .NET 4 port of the <a href="https://github.com/yui/yuitest">yuitest-coverage</a> 
and <a href="https://github.com/yui/yuitest">yuitest-coverage-reporter</a> Java apps.

It includes a pre-compiled ANTLR 3.5 Lexer and Parser for the ES3 version of JavaScript.

My goal it to be compatible with the original yuitest coverage tool, but with minor 
improvements and additional features.

## Usage
Instrumenting a single file, instrumented in place.
		
		jstestcover file.js

Instrumenting a single file, with the output to a different file.
		
		jstestcover -o file.covered.js file.js

Instrumenting a directory of files, with each file instrumented in place.
The directory is processed recursively to instrument all .js files.
		
		jstestcover -d C:\app\scripts

Instrumenting a directory of files, outputting the instrumented files to a 
different directory. Again, the directory is processed recursively.  The directory 
structure is preserved in the output directory.
		
		jstestcover -o C:\covered -d C:\app\scripts


## Current Version
The coverage tool (jstestcover.exe) supports single file and directory processing.
An exclusion list will be handle via the configuration file, which is still in development.

The report generator is in development, but the instrumented files are compatible with the 
YUITest Coverage Reporter, so it can be used instead.

## Included libraries
<a href="http://www.antlr.org/">Antlr 3.5 for .NET</a>
<br/>
<a href="https://github.com/gsscoder/commandline">Command Line Parser Library</a>

## License
jstestcover is licensed under the New BSD License.
