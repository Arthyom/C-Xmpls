import pc;

public static void main(String[] args) {
	
	Buffer b = new Buffer();

	Productor 	p = new Productor(b);
	Consumidor	c = new Consumidor(b);

	p.Start();
	c.Start();

	try {
		System.in.read();
	}catch(Exception e ){

	}
}