Gain g;
g => dac;

SinOsc a => g;
SndBuf buf;
me.sourceDir() + "/Songs_Wav/do_i_wanna_know.wav" => string music_file;
music_file => buf.read; 
0.9 => buf.rate;
10000000 => buf.pos;
buf => g;
<<< buf.samples() >>>;
3 => g.op;
20::second => now;