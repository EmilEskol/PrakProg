Out.txt: main.exe
	cat input.txt |mono $< 1> $@ 2> log
main.exe: main.cs genlist.dll
	mcs $< -target:exe -out:$@\
		$(addprefix -reference:,$(filter %.dll,$^))
		$(filter %.cs,$^)
genlist.dll: genlist.cs
	mcs $< -target:library -out:$@
clean:
	-rm *.dll *.exe [Oo]ut.log
