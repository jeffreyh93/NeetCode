/**
https://leetcode.com/discuss/interview-question/883931/Google-or-Phone-or-Encode-String

"aaabczzzzabczzzzabczzzzc -> "a(abc(z)4)3c"

This was asked during my recent phone screening, I could only come up with a solution (brute force). Need to compress the string optimally in the given format. The example is shown above. Any suggestions ?

My Algo:

    For every substring starting with index i = 0 ... len(s), find the maximum contiguous substring, starting with index i, use the found substring in result and forward the index i by substring.size() * count;
    Repeat till the i >= len(s);

However this results in the following ans

I was not able to figure out, how to do the second level of compression, where the consecutive z should be replaced with the count of occurences.
a(abcz(4))3c
*/