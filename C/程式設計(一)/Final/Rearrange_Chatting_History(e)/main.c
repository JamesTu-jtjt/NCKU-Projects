#include <stdio.h>
#include <stdlib.h>
#define MESSAGE_LENGTH 64
#define NAME_LENGTH 10

struct timestamp {
    int hour, minute;
};

struct message_info {
    struct timestamp time;
    char name[NAME_LENGTH];
    char message[MESSAGE_LENGTH];
};

int cmp(const void* a, const void* b) {
    return ( *(int*)a - *(int*)b );
}

void sort_message(struct message_info *m, int *total) {
// m is array of each message information wrapped in a struct
// total is the number of total message
    struct message_info m2[*total];
    struct timestamp t[*total];
    int tm[*total],th[*total],tt[*total];
    for(int i=0;i<*total;i++){
        tm[i]=m[i].time.minute;
        th[i]=m[i].time.hour;
        tt[i]=th[i]*100+tm[i];
    }
    qsort(tt, *total, sizeof(int),cmp);
    for(int i = 0; i < *total; i++){
        for(int k=0; k<*total; k++) {
            if (m[k].time.hour*100+m[k].time.minute == tt[i]) {
                m2[i] = m[k];
            }
        }
    }
    for(int i = 0; i < *total; i++) m[i]=m2[i];
}

int main(void) {
    struct message_info m[100];
    int total;
    scanf("%d", &total);
    for(int i = 0; i < total; i++)
        scanf("%d:%d %s %[^\n]", &m[i].time.hour, &m[i].time.minute, m[i].name, m[i].message);
    sort_message(m, &total);
    for(int i = 0; i < total; i++)
        printf("%02d:%02d %s %s\n", m[i].time.hour, m[i].time.minute, m[i].name, m[i].message);
    return 0;
}