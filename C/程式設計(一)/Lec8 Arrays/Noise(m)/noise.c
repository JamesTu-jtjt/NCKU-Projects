#include<stdio.h>

int main(){
    int i,m,n,max,max2;
    int a[2][10]={{10,9,8,7,6,5,4,3,2,1}};
    for(i=0;i<10;i++) scanf("%d",&a[1][i]);
    max2=0;
    for(m=0;m<10;m++){
        for(n=(m+1);n<10;n++){
            max=(a[1][m]+a[1][n])*(a[0][m]-a[0][n]);
            if(max>max2) max2=max;
        }
    }
    printf("%d",max2);
    return 0;
}
