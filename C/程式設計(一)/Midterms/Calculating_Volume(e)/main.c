#include<stdio.h>
#include<math.h>
#define pi 3.14

int main(){
    int mode;
    double m1,a,b,c,x,y,m4;
    scanf("%d",&mode);
    switch(mode){
        case 1 :{
            scanf("%lf", &m1);
            printf("%.2lf", pow(m1, 3));
            break;
        }
        case 2 :{
            scanf("%lf %lf %lf", &a, &b, &c);
            printf("%.2lf", a * b * c);
            break;
        }
        case 3 :{
            scanf("%lf %lf", &x, &y);
            printf("%.2lf", pi * x * x * y);
            break;
        }
        case 4 :{
            scanf("%lf", &m4);
            printf("%.2lf", sqrt(2) / 12 * pow(m4, 3));
            break;
        }
    }
    return 0;
}

