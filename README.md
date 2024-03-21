# superpower-delimited-combinator
Sample for https://github.com/datalust/superpower/issues/158

output
```console
INPUT: TEST123;TEST456;;HALLO
OUTPUT:
Value@0 (line 1, column 1): TEST123
Semicolon@7 (line 1, column 8): ;
Value@8 (line 1, column 9): TEST456
NullValue@15 (line 1, column 16): ;;
Value@17 (line 1, column 18): HALLO


INPUT: TEST123;TEST456; ;HALLO
OUTPUT:
Value@0 (line 1, column 1): TEST123
Semicolon@7 (line 1, column 8): ;
Value@8 (line 1, column 9): TEST456
NullValue@15 (line 1, column 16): ; ;
Value@18 (line 1, column 19): HALLO


INPUT: TEST123;TEST456;  ;HALLO
OUTPUT:
Value@0 (line 1, column 1): TEST123
Semicolon@7 (line 1, column 8): ;
Value@8 (line 1, column 9): TEST456
NullValue@15 (line 1, column 16): ;  ;
Value@19 (line 1, column 20): HALLO
```
