//*****************************************************************************
//** 3234. Count the Number of Substrings With Dominant Ones        leetcode **
//*****************************************************************************
//** Zeros gather softly, but ones rise like a tide,                         **
//** Their strength must square the silence where the weaker digits hide.    **
//** We count each fleeting window where the ones refuse to fall             **
//** A dominant string of courage, outnumbering nothing at all.              **
//*****************************************************************************

int numberOfSubstrings(char* s)
{
    int n = (int)strlen(s);
    long long retval = 0;

    int first1 = -1;

    for(int i = 0; i < n; i++)
    {
        if(s[i] == '1')
        {
            if(first1 == -1)
            {
                first1 = i;
            }
            retval += (long long)(i - first1 + 1);
        }
        else
        {
            first1 = -1;
        }
    }

    int limit = (int)sqrt((double)n);

    for(int zeroNum = 1; zeroNum <= limit; zeroNum++)
    {
        int zeroPos[40005];
        int head = 0, tail = 0;

        int curZeroNum = 0;
        int firstZeroI = -1;
        int oneNum = 0;

        for(int r = 0; r < n; r++)
        {
            if(s[r] == '0')
            {
                zeroPos[tail++] = r;
                curZeroNum++;

                if(curZeroNum > zeroNum)
                {
                    curZeroNum--;
                    oneNum -= (zeroPos[head] - firstZeroI - 1);
                    firstZeroI = zeroPos[head++];
                }
            }
            else
            {
                oneNum++;
            }

            if(curZeroNum == zeroNum && oneNum >= zeroNum * zeroNum)
            {
                int extendLeft = zeroPos[head] - firstZeroI;
                int extendRight = oneNum - zeroNum * zeroNum + 1;

                retval += (extendLeft < extendRight ? extendLeft : extendRight);
            }
        }
    }

    return (int)retval;
}