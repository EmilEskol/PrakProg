Out.txt: main.exe
	mono $< 1> $@ 2> log
main.exe: main.cs genlist.dll
	mcs -target:exe -out$@\
		$(addprefix -refrence:,$(filter %.dll,$^))
		$(filter %.cs,$^)
genlist.dll: genlist.cs
	mcs -target:library -out:$@ $<
clean:
	-rm *.dll *.exe [Oo]ut.log
