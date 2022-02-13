SndBuf buf;

me.sourceDir() + "/Songs_Wav/do_i_wanna_know.wav" => string music_file;
music_file => buf.read; 

buf => dac;

0.4 => buf.rate;
0 => buf.pos;
0.5 => buf.gain;

20::second => now;

// buf => dac;
//0 => buf.pos;
//0.1 => buf.gain; // volume of the song 

// 20::second => now; 
