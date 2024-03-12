package com.mordent.api.itf.process;

public interface Repository{
	void initialize();
	void destory();
	boolean available();
	Object get(String query);
}