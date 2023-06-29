
using System;
using static System.Console;
using static System.Math;
using static Integ;

public class main{
	public static void Main(string[] args){
		WriteLine("======================== Part a ======================");
		Func<double,double> f = x => Sqrt(x);
		(double a1, int c1) = integrate(f,0,1);
		//WriteLine($"{f(1)} {f(9)} {Sqrt(9)}");
		f = x => 1/Sqrt(x);
		(double a2,int c2) = integrate(f,0,1);
		WriteLine($"integrate Sqrt(x) gives {a1} from 0 to 1 and used {c1} iterations");
		WriteLine($"integrate 1/Sqrt(x) gives {a2} from 0 to 1 and used {c2} iterations");
		f = x => 4*Sqrt(1-x*x);
		(double a3,int c3) = integrate(f,0,1);
		WriteLine($"This should be PI: {a3} and {c3} iterations was used");
		f = x => Log(x)/Sqrt(x);
		(double a4,int c4) = integrate(f,0,1);
		WriteLine($"Log(x)/Sqrt(x) from 0 to 1 gives {a4} and used {c4} iterations");

		double[] xs = new double[128];
		double[] ys = new double[128];

		double[] ys1 = {0,0.022564575,0.045111106, 0.067621594, 0.090078126, 0.112462916, 0.222702589,0.328626759, 0.428392355, 0.520499878, 0.603856091, 0.677801194, 0.742100965, 0.796908212, 0.842700793, 0.880205070, 0.910313978, 0.934007945, 0.952285120, 0.966105146, 0.976348383, 0.983790459, 0.989090502, 0.992790429, 0.995322265, 0.997020533, 0.998137154, 0.998856823, 0.999311486, 0.999593048, 0.999977910, 0.999999257};
		double[] xs1 = new double[ys1.Length];
		double[] ys2 = new double[ys1.Length];
		double[] ys3 = new double[ys1.Length];
		for(int i=0;i<ys1.Length;i++){
			if(i<=5)
				xs1[i]=i*0.02;
			else if(i<=29)
				xs1[i]=(i-4)*0.1;
			else if(i<ys2.Length)
				xs1[i]=(i-24)*0.5;
			ys2[i]=erf(xs1[i])-ys1[i];
			ys3[i]=erf2(xs1[i])-ys1[i];
		}
		for(int i=0;i<xs.Length;i++){
			double xVal=i*1.0/16-4;
			xs[i]=xVal;
			ys[i]=erf(xVal);
		}
		IOputs.WriteXY(args,xs,ys,"Erf.data");
		IOputs.WriteXY(args,xs1,ys1,"erfTab.data");
		IOputs.WriteXY(args,xs1,ys2,"ErfCompare1.data");
		IOputs.WriteXY(args,xs1,ys3,"ErfCompare2.data");
		WriteLine("======================== Part b ======================");
		f = x => 1.0/Sqrt(x);
		(a1, c1)=integrateCC(f,0,1);
		f = x => Log(x)/Sqrt(x);
		(a2,c2)=integrateCC(f,0,1,0.0001,0);
		WriteLine($"Log(x)/Sqrt(x) from 0 to 1 gives {a2} and used {c2} iterations");
		WriteLine("scipy.integrate.quad gets -3.999999999999974 with 315 evaluations");
		WriteLine("Which shows the .quad method is better");
		WriteLine($"1/Sqrt(x) from 0 to 1 gives {a1} and used {c1} iterations");
	}
	public static double erf(double z){
		if(z<0)
			return -erf(-z);
		else if(z<=1){
			(double I1,int N1)=integrate(x => Exp(-x*x),0,z);
			return 2/Sqrt(PI)*I1;
		}
		else{
			(double I2,int N2)=integrate(x => Exp(-Pow((z+(1-x)/x),2))/x/x,0,1);
			return 1-2/Sqrt(PI)*I2;
		}
	}
	public static double erf2(double x){
		if(x<0) return -erf(-x);
		double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
		double t=1/(1+0.3275911*x);
		double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));
		return 1-sum*Exp(-x*x);
	}
}
