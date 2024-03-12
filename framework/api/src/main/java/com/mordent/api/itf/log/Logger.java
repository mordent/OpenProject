package com.mordent.api.itf.log;

public interface Logger extends org.slf4j.Logger{
    public void trace(Throwable throwable);
    public void debug(Throwable throwable);
    public void info(Throwable throwable);
    public void warn(Throwable throwable);
    public void error(Throwable throwable);
    
    public void trace(Throwable throwable, String str);
    public void debug(Throwable throwable, String str);
    public void info(Throwable throwable, String str);
    public void warn(Throwable throwable, String str);
    public void error(Throwable throwable, String str);

    public void trace(Throwable throwable, String str, Object ... args);
    public void debug(Throwable throwable, String str, Object ... args);
    public void info(Throwable throwable, String str, Object ... args);
    public void warn(Throwable throwable, String str, Object ... args);
    public void error(Throwable throwable, String str, Object ... args);
}