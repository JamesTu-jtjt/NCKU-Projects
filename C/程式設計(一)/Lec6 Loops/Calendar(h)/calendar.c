#include <stdio.h>


int main() {
    int m, i;
    scanf("%d", &m);
    printf("Sun Mon Tue Wed Thu Fri Sat"" ""\n");
    switch (m) {
        case 1:
            printf("%12s", " ");
            for (i = 1; i <= 31; i++) {
                printf("%3d ",i);
                if(i%7==4) printf("\n");
            }
            break;
        case 2:
            printf("%24s", " ");
            for (i = 1; i <= 29; i++) {
                printf("%3d ",i);
                if(i==1) printf("\n");
                if(i==8) printf("\n");
                if(i==15) printf("\n");
                if(i==22) printf("\n");
            }
            break;
        case 3:
            for (i = 1; i <= 31; i++) {
                printf("%3d ",i);
                if(i%7==0) printf("\n");
            }
            break;
        case 4:
            printf("%12s", " ");
            for (i = 1; i <= 30; i++) {
                printf("%3d ",i);
                if(i%7==4) printf("\n");
            }
            break;
        case 5:
            printf("%20s", " ");
            for (i = 1; i <= 31; i++) {
                printf("%3d ",i);
                if(i%7==2) printf("\n");
            }
            break;
        case 6:
            printf("%4s", " ");
            for (i = 1; i <= 30; i++) {
                printf("%3d ",i);
                if(i%7==6) printf("\n");
            }
            break;
        case 7:
            printf("%12s", " ");
            for (i = 1; i <= 31; i++) {
                printf("%3d ",i);
                if(i%7==4) printf("\n");
            }
            break;
        case 8:
            printf("%24s", " ");
            for (i = 1; i <= 31; i++) {
                printf("%3d ",i);
                if(i%7==1) printf("\n");
            }
            break;
        case 9:
            printf("%8s", " ");
            for (i = 1; i <= 30; i++) {
                printf("%3d ",i);
                if(i%7==5) printf("\n");
            }
            break;
        case 10:
            printf("%16s", " ");
            for (i = 1; i <= 31; i++) {
                printf("%3d ",i);
                if(i==3) printf("\n");
                if(i==10) printf("\n");
                if(i==17) printf("\n");
                if(i==24) printf("\n");
            }
            break;
        case 11:
            for (i = 1; i <= 30; i++) {
                printf("%3d ",i);
                if(i%7==0) printf("\n");
            }
            break;
        case 12:
            printf("%8s", " ");
            for (i = 1; i <= 31; i++) {
                printf("%3d ",i);
                if(i%7==5) printf("\n");
            }
            break;
    }
    return 0;
}
