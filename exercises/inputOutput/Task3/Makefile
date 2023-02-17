Out.txt: main.exe
	mono main.exe -input:input.txt -output:Out.txt
main.exe: main.cs
	mcs $^ -target:exe -out:$@
clean:
	-rm -f main.exe Out.txt
