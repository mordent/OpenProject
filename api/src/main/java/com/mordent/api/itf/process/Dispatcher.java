package com.mordent.api.itf.process;

import com.mordent.api.itf.event.Request;
import com.mordent.api.itf.event.Response;

public interface Dispatcher{
	Response execute(Request interfaceRequest);
	Request getRequest();
}