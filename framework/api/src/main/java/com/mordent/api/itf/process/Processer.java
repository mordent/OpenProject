 package com.mordent.api.itf.process;

import com.mordent.api.itf.event.Request;

public interface Processer{
	void pre(Request request);
	void post(Request request);
}