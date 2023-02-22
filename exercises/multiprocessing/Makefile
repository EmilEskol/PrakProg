TIME = time --portability --append --output $@

N = 1e8
Out.txt: main.exe
	>$@
	$(TIME)  mono $< -terms:$N -threads:1 >> $@
	$(TIME)  mono $< -terms:$N -threads:2 >> $@
	$(TIME)  mono $< -terms:$N -threads:3 >> $@
	$(TIME)  mono $< -terms:$N -threads:4 >> $@
main.exe: main.cs
	mcs $<

test: out1 out2 out3 out4
out1:main.exe; 	$(TIME)  mono $< -terms:$N -threads:4 >> $@
out2:main.exe; 	$(TIME)  mono $< -terms:$N -threads:4 >> $@
out3:main.exe; 	$(TIME)  mono $< -terms:$N -threads:4 >> $@
out4:main.exe; 	$(TIME)  mono $< -terms:$N -threads:4 >> $@
