using static System.Math;
using static System.Console;
using static cmath;

static class main{
	static int Main(){
	int returnValue=0;
	complex c1=new complex(1,0);
	complex ci=new complex(0,1);

	complex sqrt1=sqrt(-c1);
	complex sqrti=sqrt(ci);
	complex eI=exp(ci);
	complex eIpi=exp(ci*PI);
	complex iI = ci.pow(ci);
	complex lni = log(ci);
	complex sinipi = sin(ci*PI);
	
	Write($"sqrt(-1)={sqrt1}\n");
	Write($"e^i={eI}\n");
	Write($"e^ipi={eIpi}\n");
	Write($"i^i={iI}\n");
	Write($"ln(i)={lni}\n");
	Write($"sin(i*pi)={sinipi}\n");

	//From Wolphram
	complex Wsqrt1=new complex(0,+-1);
	complex Wsqrti=new complex(0.707106781186547524400844362104849039284835937688474036
							  ,0.707106781186547524400844362104849039284835937688474036);
	complex WeI=new complex(0.54030230586813971740093660744297660373231042061792222,
							0.84147098480789650665250232163029899962256306079837106);
	complex WeIpi=new complex(-1,0);
	complex WiI = new complex(0.2078795763507619085469556198349787700338778416317696080751358830,0);
	complex Wlni = new complex(0,1.570796326794896619231321691639751442098584699687552910487472296);
	complex Wsinipi = new complex(0,11.54873935725774837797733431538840968449518906639478945523216336);

	Write("Testing sqrt(-1)\n");
	if(sqrt1.approx(Wsqrt1)){
		Write("Succes\n");}
	else{
		Write("Failed"); returnValue++;}
		
	Write("Testing sqrt(-i)\n");
	if(sqrti.approx(Wsqrti)){
		Write("Succes\n");}
	else{
		Write("Failed"); returnValue++;}
		
	Write("Testing e^i\n");
	if(eI.approx(WeI)){
		Write("Succes\n");}
	else{
		Write("Failed"); returnValue++;}

	Write("Testing e^(i*pi)\n");
	if(eIpi.approx(WeIpi)){
		Write("Succes\n");}
	else{
		Write("Failed"); returnValue++;}

	Write("Testing i^i\n");
	if(iI.approx(WiI)){
		Write("Succes\n");}
	else{
		Write("Failed"); returnValue++;}

	Write("Testing ln(i)\n");
	if(lni.approx(Wlni)){
		Write("Succes\n");}
	else{
		Write("Failed"); returnValue++;}

	Write("Testing sin(i*pi)\n");
	if(sinipi.approx(Wsinipi)){
		Write("Succes\n");}
	else{
		Write("Failed"); returnValue++;}
	
	return returnValue;
	}
}
