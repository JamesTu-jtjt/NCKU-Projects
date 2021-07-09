#include<stdio.h>

int main(){
    int i,j,k,n;
    scanf("%d",&n);
    int a[n][n];
    k=1;
    for (i = 0; i < n; i++) {
        for (j = 0; j < n; j++) {
            scanf("%d", &a[i][j]);
        }
    }
    for(i=1;i<n;i++){
        for(j=0;j<i;j++){
            if(a[i][j]!=a[j][i]) {
                k=0;
                break;
            }
        }
    }
    if (k==1){
        printf("Yes\n");
    }
    else printf("No\n");
    return 0;
}
