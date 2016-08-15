public class Productor extends Thread{

	private Buffer buffer;

	private final String letras = " abcdefghijklmnopqrkstuvwxyz";
	public Productor ( Buffer buffer ){
		this.buffer = buffer;
	}

	@Override
	public void run ( ){
		for ( int i = 0 ; i < 10 ; i ++ ){
			char c = letras.charAt( (int)  Math.random() * letras.length() ) );
			buffer.poner(c);
			System.out.println(i+" Productor: "+ c);
			try {
				Thread.sleep(400);
			}catch (InterruptedException e){

			}
		}
	}
}