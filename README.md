# CreativeTechnology
String Calculator

To run application from command prompt:

Go to exe path: for example,
~\StringCalculator\stringcalc\bin\Debug\netcoreapp3.1>

Empty string:
stringcalc 

Single number:
stringcalc 1

Two numbers:
stringcalc 1,2

Any count numbers:
stringcalc 1,2,3,10

Comma and new lines allowed
stringcalc 1\n2,3

Invalid input
stringcalc 1,\n

Support different single character delimiter
stringcalc //;\n1;2

Negative numbers not allowed
stringcalc //;\n1;-2;3;-4;5

Numbers greater than 1000 should be ignored
stringcalc //;,\n2;1001;13

Allow multiple delimiters
stringcalc //*%\n1*2%3

