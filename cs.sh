echo "running cs/T$1.cs"

mcs ./cs/T$1.cs
mono ./cs/T$1.exe

rm ./cs/T$1.exe