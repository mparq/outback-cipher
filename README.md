Run on input.txt by using command

```
dotnet build
gc .\input.txt | Foreach-Object {$split = $_.Split(" "); dotnet .\bin\Debug\netcoreapp1.1\outback-cipher.dll $split[0] ($split[1..($split.length-1)] -join " ")} | Out-File output.txt
```