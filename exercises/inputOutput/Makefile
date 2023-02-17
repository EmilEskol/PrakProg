#Out.txt: main.exe
	#mono main.exe $(cat inputfile)> Out.txt
main.exe: main.cs
	mcs $^ -target:exe -out:$@
stdin.exe: stdin.cs
	mcs $^ -target:exe -out:$@
strin.exe: strin.cs
	mcs $^ -target:exe -out:$@
clean:
	-rm -f stdin.exe strin.exe main.exe Out.txt
