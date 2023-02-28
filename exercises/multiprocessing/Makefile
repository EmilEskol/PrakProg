TIME = time --portability --append --output $@

N = 1e8
Out.txt: main.exe parallel.exe
	>$@
	$(TIME)  mono $< -terms:$N -threads:1 >> $@
	$(TIME)  mono $< -terms:$N -threads:2 >> $@
	$(TIME)  mono $< -terms:$N -threads:3 >> $@
	$(TIME)  mono $< -terms:$N -threads:4 >> $@
	$(TIME)  mono parallel.exe -terms:$N >>  $@
main.exe: main.cs
	mcs $<
parallel.exe: parallel.cs
	mcs $<
clean:
	rm -f Out.txt  main.exe
