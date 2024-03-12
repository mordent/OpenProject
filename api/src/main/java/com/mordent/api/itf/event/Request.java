package com.mordent.api.itf.event;

import java.util.Map;

import com.mordent.api.itf.context.Context;
import com.mordent.api.itf.message.Document;

public interface Request{
	Context getContext();
	Document getDocument();
	Response getResponse();

	String getURI();
	Map<String,Object> getHeader();
	Map<String,Object> getParameter();
	String getMessage();
}