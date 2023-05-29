using System;
using static System.Console;
using static System.Math;
using static matrix;

public static class Minimi{
	static int dim,i;
	static double fx,lambda,uTy,minFx;
	static vector grade,x,y,delX,s,minX;
	static matrix B,delB,u;
	
	public static vector qnewton(Func<vector,double> f, vector start, double acc){
		dim=start.size;
		x=start.copy();
		B=id(dim);
		grade=gradian(f,x);
		u=new matrix(dim,1);
		i=0;
		fx=f(x);
		minFx=1;
		do{
			delX=-B*grade;
			lambda=1;
			while(f(x+lambda*delX)>fx &&  lambda>Pow(2,-13)){
				lambda/=2;
			}
			if(lambda>Pow(2,-13)){
				//WriteLine($"step nr {i} f(x) = {fx}, grade={grade.norm()} ");
				s=lambda*delX;
				y=gradian(f,x+s)-grade;
				for(int i=0;i<dim;i++)
					u[i,0]=(s-B*y)[i];
				uTy=(u.T*y)[0];
				if(Abs(uTy)>Pow(10,-6)){
					delB=(u*u.T)/uTy;
					B=B+delB;
				}
			}
			else{
				B.set_unity();
			}			
			x += lambda*delX;
			grade=gradian(f,x);
			i++;
			fx=f(x);

			//Info gatheret between runs
			/*if(i%5000==0){
				WriteLine($"i= {i} f(x)= {fx}, grade={grade.norm()}");
				x.print("");
			}*/
			if(minFx>=fx){
				//x.print($"f(x)={fx}, grade= {grade.norm()}, x=");
				minFx=fx;
				minX=x.copy();
			}
			if(i>=30000){
				WriteLine($"The gradian of the last step (step nr {i}) is {grade.norm()}");
				minX.print("and the best found value is f(x) = {minfx} with x=");
				return minX;
			}	
		}while(grade.norm()>acc);
		WriteLine($"f(x) = {f(x)}. The gradian of the last step (step nr {i}) is {grade.norm()} ");
		return x;
	}
	public static vector gradian(Func<vector,double> f,vector x1){
		vector result=new vector(dim);
		for(int i=0;i<dim;i++){
			double dx=Abs(x1[i])*Pow(2,-26);
			if(dx==0)
				dx=Pow(2,-26);
			vector xi=x1.copy();
			xi[i]+=dx;
			result[i]=(f(xi)-f(x1))/dx;
		}
		return result;
	}
}
