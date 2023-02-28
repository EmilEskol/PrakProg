task: erf.svg gamma.svg

erf.svg: erf.gpi erf.data erfTab.data
	gnuplot $< > $@
erf.data: main1.exe
	mono $< > $@
erfTab.data: erfTab.exe
	mono $< > $@
erfTab.exe: erfTabData.cs
	mcs $< -target:exe -out:$@
main1.exe: main1.cs sfuns.dll
	mcs $< -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^))

gamma.svg: gamma.gpi gamma.data factorials.data
	gnuplot $< > $@
gamma.data: main2.exe
	mono $< >$@
main2.exe: main2.cs sfuns.dll
	mcs $< -target:exe -out:$@ $(addprefix -reference:,$(filter %.dll,$^))
factorials.data:sfuns.dll
	>$@
	echo 0 1 >>$@
	echo 1 1 >>$@
	echo 2 2 >>$@
	echo 3 6 >>$@


sfuns.dll: erf.cs gamma.cs
	mcs $^ -target:library -out:$@


clean:
	rm -f *.dll *.exe *.data *.svg
