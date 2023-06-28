using System;
using static System.Math;
using static System.Console;
using static matrix;
using static EVD;

static class main{
	static int Main(string[] args){
		int returnCode=0;
		WriteLine("Part A");
		bool test=false;
		var rnd = new Random();
		int maxInt = 5;
		int n=rnd.Next(3,maxInt);
		matrix A = new matrix(n,n);
		matrix I = matrix.id(n);
		int ran=0;
		for(int i=0;i<n;i++){
			for(int j=0;j<n;j++){
				ran=rnd.Next(0,100);
				if(i>=j){
					A[i,j]=ran;
					A[j,i]=ran;
				}
			}
		}
		A.print("A: \n");
		(matrix V,vector w)= Eigen(A);
		V.print("V: \n");
		matrix VT=V.transpose();
		matrix D=matrix.id(n);
		for(int i=0;i<n;i++)
			D[i,i]=w[i];
		D.print("D: \n");
		
		Write("Testing if V^T*A*V=D...");
		if(!D.approx(VT*A*V))
			test=true;
			
		if(test){
			returnCode++;
			Write("Test failed\n");
			test=false;
		}else Write("Test passed\n");

		Write("Testing if V*D*V^T=A...");
		
		if(!A.approx(V*D*VT))
			test=true;
			
		if(test){
			returnCode++;
			Write("Test failed\n");
			test=false;
		}else Write("Test passed\n");
		
		Write("Testing if V^T*V=1...");
		if(!I.approx(VT*V))
			test=true;
			
		if(test){
			returnCode++;
			Write("Test failed\n");
			test=false;
		}else Write("Test passed\n");

		Write("Testing if V*V^T=1...");
		if(!I.approx(V*VT))
			test=true;
			
		if(test){
			returnCode++;
			Write("Test failed\n");
			test=false;
		}else Write("Test passed\n");
		partB(args);
		return returnCode;
	}
	public static void partB(string[] args){
		WriteLine("Part b");
		double rmax=0;
		double dr=0;
		foreach(var arg in args){
			var words=arg.Split(':');
			if(words[0]=="-rmax")
				rmax=float.Parse(words[1]);
			if(words[0]=="-dr")
				dr=float.Parse(words[1]);
		}
		matrix H=calcH(rmax,dr);
		//H.print("H= ");
		(matrix F,vector E) = Eigen(H);
		WriteLine($"The found energy is {E[0]}");
		genlist<double> xs= new genlist<double>();
		genlist<double> ys= new genlist<double>();
		genlist<double> Es= new genlist<double>();  //theoretical values
		for(double i=0.1;i<1;i+=0.1){
			H=calcH(10,i);
			(F,E) = Eigen(H);
			xs.add(i);
			ys.add(E[0]);
			Es.add(-0.5);
		}
		IOputs.WriteXY(args,xs,ys,"Delr.data");
		IOputs.WriteXY(args,xs,Es,"TheoDelr.data");
		xs= new genlist<double>();
		ys= new genlist<double>();
		for(double i=6;i<15;i++){
			H=calcH(i,0.3);
			(F,E) = Eigen(H);
			xs.add(i);
			ys.add(E[0]);
			Es.add(-0.5);
		}
		IOputs.WriteXY(args,xs,ys,"Rmax.data");
		IOputs.WriteXY(args,xs,Es,"TheoRmax.data");

		H=calcH(10,0.1);
		(F,E) = Eigen(H);
		xs= new genlist<double>();
		ys= new genlist<double>(); //Found values
		genlist<double> ys1= new genlist<double>(); //Found values
		Es= new genlist<double>(); //theoretical values
		genlist<double> Es1= new genlist<double>(); //theoretical values
		double r;
		for(int i=0;i<F.size1;i++){
			r=0.1*(i+1);
			ys.add(F[i,0]/Sqrt(0.1));
			ys1.add(F[i,1]/Sqrt(0.1));
			xs.add(r);
			Es.add(2*r*Exp(-r));
			Es1.add(-1.0/Sqrt(2)*r*(1-r/2)*Exp(-r/2));
		}
		IOputs.WriteXY(args,xs,ys,"Wavefunc.data");
		IOputs.WriteXY(args,xs,ys1,"Wavefunc1.data");
		IOputs.WriteXY(args,xs,Es1,"TheoWavefunc1.data");
		IOputs.WriteXY(args,xs,Es,"TheoWavefunc.data");

	}
	public static matrix calcH(double rmax,double dr){
		int nPoints=(int)(rmax/dr)-1;
		vector r = new vector(nPoints);
		for(int i=0;i<nPoints;i++)
			r[i]=dr*(i+1);
		matrix H = new matrix(nPoints,nPoints);
		for(int i=0;i<nPoints-1;i++){
			H[i,i]= -2;
			H[i,i+1]=1;
			H[i+1,i]=1;
		}
		H[nPoints-1,nPoints-1]=-2;
		scale(H,-0.5/dr/dr);
		for(int i=0;i<nPoints;i++)
			H[i,i]+=-1/r[i];
		return H;
	}
}
