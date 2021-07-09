#include<stdio.h>

int main(){
    int y,age,h,w;
    float bmi;
    scanf("%d %d %d",&y,&h,&w);
    age=2020-y+1;
    bmi=w/((h/100.0)*(h/100.0));
    printf("Age = %d\nHeight = %dcm\nWeight = %dkg\nBMI = %.1f\n",age,h,w,bmi);
    if(age<19 || age>36) printf("Not a Draftee (age < 19 or age > 36 years old)\nNo need to perform Military Service");
    else {
        if (bmi >= 17 && bmi <= 31) {
            if(y<=1993) printf("Physical Status of Regular Service Draftees\n1 year of Regular Service");
            else printf("Physical Status of Regular Service Draftees\n4 months of Regular Service");
        }
        else if(bmi<16.5||bmi>31.5){
            printf("Physical Status of Military Service Exemption\nExemption from Military Service");
        }
        else{
            if(y<=1993) printf("Physical Status of Substitute Service Draftees\nSubstitute Services");
            else printf("Physical Status of Substitute Service Draftees\nReplacement Service");
        }

    }
    return 0;
}
