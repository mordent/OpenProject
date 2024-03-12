package com.mordent.api.factory;

import java.security.AccessController;
import java.security.PrivilegedAction;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.ServiceLoader;

import com.mordent.api.itf.event.Request;
import com.mordent.api.itf.event.Response;
import com.mordent.api.itf.initialize.Provider;
import com.mordent.api.itf.log.Logger;
import com.mordent.api.itf.log.LoggerFactory;
import com.mordent.api.itf.process.Dispatcher;
import com.mordent.api.itf.process.Processer;

public final class Factory {
	private static LoggerFactory loggerFactory = null;
	private static Logger logger = null;
	
	private Factory(){}

	private static LoggerFactory getLoggerFactory() {
		if(loggerFactory == null) {
			loggerFactory = getFirstClass(LoggerFactory.class);
			loggerFactory.initialize();
		}
		if(logger == null) {
			loggerFactory.getLogger(Factory.class);
		}
		return loggerFactory;
	}
	
	public static Logger getLogger(Class<?> cls) {
		return getLoggerFactory().getLogger(cls);
	}

	public static Logger getLogger(String loggerName) {
		return getLoggerFactory().getLogger(loggerName);
	}	
	
	public static void initialize () {
		List<Provider> providerList = null;
		try {
			providerList = getClassList(Provider.class);
			if(providerList == null || providerList.isEmpty()) {
				throw new RuntimeException("Provider Not Found");
			}
			if(providerList.size() > 1) {

				throw new RuntimeException("Provider Duplicate");
			}
			providerList.get(0).getInitializer().initialize();
		}catch(Exception e) {
		}
	}
	
	public static Request makeRequest(String uri, String body, Map<String, Object> header, Map<String, Object> parameter) {
		return null;
	}
	
	public static Processer getProcesser(Request request) {
		return null;
	}
	
	public static Dispatcher getDispatcher(Request request) {
		return null;
	}

	
	public static Response execute(String uri, String body, Map<String, Object> header, Map<String, Object> parameter) {
		Request request = null;
		Processer processer = null;
		Dispatcher dispatcher = null;
		Response resonse = null;
		try {
			request = makeRequest(uri, body, header, parameter);
			processer = getProcesser(request);
			dispatcher = getDispatcher(request);
		}catch(Exception e) {
			e.printStackTrace();
		}
		try {
			processer.pre(request);
		}catch(Exception e) {
			e.printStackTrace();
		}
		try {
			resonse = dispatcher.execute(request);
		}catch(Exception e) {
			e.printStackTrace();
		}
		try {
			processer.post(request);
		}catch(Exception e) {
			e.printStackTrace();
		}
		return resonse;
	}
	
    private static <T> ServiceLoader<T> getServiceLoader(Class<T> cls) {
        ServiceLoader<T> serviceLoader;
        SecurityManager securityManager = System.getSecurityManager();
        if(securityManager == null) {
            serviceLoader = ServiceLoader.load(cls);
        } else {
            final PrivilegedAction<ServiceLoader<T>> action = () -> ServiceLoader.load(cls);
            serviceLoader = AccessController.doPrivileged(action);
        }
        return serviceLoader;
    }

    private static <T> List<T> getClassList(Class<T> cls){
    	List<T> list = null;
    	ServiceLoader<T> serviceLoader = getServiceLoader(cls);
    	if(serviceLoader == null) {
    		return list;
    	}
    	list = new LinkedList<>();
    	Iterator<T> iterator = serviceLoader.iterator();
    	while(iterator.hasNext()) {
    		list.add(iterator.next());
    	}
    	return list;
    }
    
	private static <T> T getFirstClass(Class<T> cls){
    	List<T> list = getClassList(cls);
    	if(list == null || list.isEmpty()) {
    		return null;
    	}
    	return list.get(0);
    }
}
