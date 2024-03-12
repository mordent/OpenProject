package com.mordent.api.itf.log;

public interface LoggerFactory{
	public void initialize();
	public Logger getLogger(Class<?> cls);
	public Logger getLogger(String loggerName);
}