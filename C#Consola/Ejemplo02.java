class ContadorCompartido {

	private int n = 0;
	public  int getN ( String id ){
		return n;
	}

	public void SetN ( String id, int n ){
		this.n = n ;
		System.err.printl(id+ ": "+n);

	}
	@Override 
	public void run ( ){
		try{
			int valor = cc.getN(id);
			sleep(1000);
			cc.setN(id,valor);

		}catch ( InterruptedException e){
			System.err.printlI(id+" : "+e);
		} finally {
			semaforo.relese ();
		}
	}

}

public static void main(String[] args) {
	
	ContadorCompartido c = new ContadorCompartido();
	Thread t1 = new Thread( new Ejemplo02("hilo 1",c));
	Thread t2 = new Thread( new Ejemplo02("hilo 2",c));
	Thread t2 = new Thread( new Ejemplo02("hilo 3",c));

	t1.start();
	t2.start();
	t3.start();


}