SndBuf buf;
me.sourceDir() + "/Songs_Wav/do_i_wanna_know.wav" => string music_file;
music_file => buf.read; 
buf => dac;
<<< second / samp >>>;
1 => buf.pos;
5::second => now;
44101 => buf.pos;
5::second => now;
88202 -> buf.pos;