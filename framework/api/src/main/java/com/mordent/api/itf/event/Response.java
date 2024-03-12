package com.mordent.api.itf.event;

import com.mordent.api.itf.context.Context;
import com.mordent.api.itf.message.Document;

public interface Response{
	Context getContext();
	Document getDocument();
	Request getRequest();

	boolean complete();
	boolean success();
	String getMessage();
	String getCode();
	String getDescription();
	String getTrace();	
}