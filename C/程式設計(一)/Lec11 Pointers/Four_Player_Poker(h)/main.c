#include <stdbool.h>
#include <stdio.h>
#define NUM_RANKS 13
#define NUM_SUITS 4
#define NUM_CARDS 5

int num_in_rank[NUM_RANKS];
int num_in_suit[NUM_SUITS];
bool straight, flush, four, three;
int pairs, high, hcard[2]={0,0};
int buff[2][5];

void read_cards(void)
{
    bool card_exists[NUM_RANKS][NUM_SUITS];
    char ch, rank_ch, suit_ch;
    int rank, suit;
    int cards_read = 0;
    for (rank = 0; rank < NUM_RANKS; rank++) {
        num_in_rank[rank] = 0;
        for (suit = 0; suit < NUM_SUITS; suit++)
            card_exists[rank][suit] = false;
    }
    for (suit = 0; suit < NUM_SUITS; suit++)
        num_in_suit[suit] = 0;
    while (cards_read < NUM_CARDS) {
        rank_ch = getchar();
        switch (rank_ch) {
            case '2': rank = 0; break;
            case '3': rank = 1; break;
            case '4': rank = 2; break;
            case '5': rank = 3; break;
            case '6': rank = 4; break;
            case '7': rank = 5; break;
            case '8': rank = 6; break;
            case '9': rank = 7; break;
            case 't': rank = 8; break;
            case 'j': rank = 9; break;
            case 'q': rank = 10; break;
            case 'k': rank = 11; break;
            case 'a': rank = 12; break;
        }
        suit_ch = getchar();
        switch (suit_ch) {
            case 'c': suit = 0; break;
            case 'd': suit = 1; break;
            case 'h': suit = 2; break;
            case 's': suit = 3; break;
        }
        buff[0][cards_read]=rank;
        buff[1][cards_read]=suit;
        ch=getchar();
        num_in_rank[rank]++;
        num_in_suit[suit]++;
        card_exists[rank][suit] = true;
        cards_read++;
    }
}
void analyze_hand(void)
{
    int num_consec = 0;
    int rank, i, suit;
    straight = false;
    flush = false;
    four = false;
    three = false;
    pairs = 0;
    //check flush
    for (suit = 0; suit < NUM_SUITS; suit++)
        if (num_in_suit[suit] == NUM_CARDS)
            flush = true;
    //check straight
    rank = 0;
    while (num_in_rank[rank] == 0) rank++;
    for (; rank < NUM_RANKS && num_in_rank[rank] > 0; rank++)
        num_consec++;
    if (num_consec == NUM_CARDS) {
        straight = true;
        return;
    }
    //check 4,3,2
    for (rank = 0; rank < NUM_RANKS; rank++) {
        if (num_in_rank[rank] == 4) {
            four = true;
            hcard[0] = rank;
        }
        if (num_in_rank[rank] == 3) {
            three = true;
            hcard[0] = rank;
        }
        if (num_in_rank[rank] == 2) {
            pairs++;
        }
    }
}
void print_result(void)
{
    int i;
    if (straight && flush) high=8;
    else if (four) high=7;
    else if (three && pairs == 1) high=6;
    else if (flush) high=5;
    else if (straight) high=4;
    else if (three) high=3;
    else if (pairs == 2) high=2;
    else if (pairs == 1) high=1;
    else high=0;
    switch(high){
        case 8: case 5: case 4: case 0: {
            for (i = 0; i < 5; i++) {
                if (buff[0][i] > hcard[0]) {
                    hcard[0] = buff[0][i];
                    hcard[1] = buff[1][i];
                }
                else if (buff[0][i] == hcard[0]) {
                    if (hcard[1] < buff[1][i]) hcard[1] = buff[1][i];
                }
            }
        }
        case 2: case 1: {
            for (i = 0; i < NUM_RANKS; i++) if (num_in_rank[i] == 2) hcard[0] = i;
            for(i=0;i<5; i++) if(buff[0][i] == hcard[0]) if (hcard[1] < buff[1][i]) hcard[1] = buff[1][i];
        }
    }
}
int main(void){
    char p[4];
    int hands[4],highc[2][4], h[4]= {0, 0, 0, 0};
    int i,j;
    for(i=0;i<4;i++){
        read_cards();
        analyze_hand();
        print_result();
        hands[i]=high;
        highc[0][i]=hcard[0];
        highc[1][i]=hcard[1];
        for(j=0;j<5;j++) {
            buff[0][j]=0;
            buff[1][j]=0;
        }
        hcard[0]=0;
        hcard[1]=0;
    }
    for(i=0;i<4;i++){
        if(hands[i]>hands[(i+1)%4]) h[i]+=1;
        else if(hands[i]==hands[(i+1)%4]) {
            if (highc[0][i] > highc[0][(i + 1) % 4]) h[i] += 1;
            else if (highc[0][i] == highc[0][(i + 1) % 4])
                if(highc[1][i]>highc[1][(i+1)%4]) h[i] += 1;
        }
        if(hands[i]>hands[(i+2)%4]) h[i]+=1;
        else if(hands[i]==hands[(i+2)%4]) {
            if (highc[0][i] > highc[0][(i + 2) % 4]) h[i] += 1;
            else if (highc[0][i] == highc[0][(i + 2) % 4])
                if(highc[1][i]>highc[1][(i+2)%4]) h[i] += 1;
        }
        if(hands[i]>hands[(i+3)%4]) h[i]+=1;
        else if(hands[i]==hands[(i+3)%4]) {
            if (highc[0][i] > highc[0][(i + 3) % 4]) h[i] += 1;
            else if (highc[0][i] == highc[0][(i + 3) % 4])
                if(highc[1][i]>highc[1][(i+3)%4]) h[i] += 1;
        }
    }
    p[h[0]]='A';
    p[h[1]]='B';
    p[h[2]]='C';
    p[h[3]]='D';
    for(i=3;i>=0;i--) printf("%c ",p[i]);
    return 0;
}