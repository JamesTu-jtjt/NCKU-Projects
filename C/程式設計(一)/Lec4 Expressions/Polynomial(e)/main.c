#include<stdio.h>
#include<math.h>

int main(){
    float a;
    scanf("%f", &a);
    printf("%.1f",7*pow(a,4)-8*pow(a,3)-a*a+6*a-22);
    return 0;
}