using System;
using static System.Console;
using static System.Math;
using static matrix;

public static class Roots{
	public static vector NMBL(Func<vector,vector> f, vector x, double eps=1e-2){
		int dim=x.size;
		//int i=0;
		vector delX,x1;
		x1=x.copy();
		double val,lambda,fx1;
		matrix jacobi,Q,R;
		do{
			//i++;
			jacobi=jacobian(f,x1);
			(Q,R)=QRGS.decomp(jacobi);
			delX=QRGS.solve(Q,R,-f(x1));
			lambda=1;
			fx1=f(x1).norm();
			while(f(x1+lambda*delX).norm()>(1-lambda/2)*fx1 &&  lambda>Pow(2,-15)){
				lambda/=2;
			}
			x1 += lambda*delX;
			val = f(x1).norm();
			//x1.print("new x guess");
		}while(val>eps);
		//WriteLine($"Number of iterations {i}");
		return x1;
	}
	public static matrix jacobian(Func<vector,vector> f, vector x){
		int dim=x.size;
		double dx;
		matrix jacobi= new matrix(dim,dim);
		vector xj = new vector(dim);
		for(int i=0;i<dim;i++){
			for(int j=0;j<dim;j++){
				dx=Abs(x[i])*Pow(2,-26);
				xj=x.copy();
				xj[j]+=dx;
				jacobi[i,j]=(f(xj)[i]-f(x)[i])/dx;
			}
		}
		return jacobi;
	}
}
