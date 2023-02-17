Out.txt: main.exe
	echo 1 2 3 4 5| mono main.exe > Out.txt
main.exe: main.cs
	mcs $^ -target:exe -out:$@
clean:
	-rm -f main.exe Out.txt
