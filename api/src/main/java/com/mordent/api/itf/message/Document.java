package com.mordent.api.itf.message;

import java.util.Map;

public interface Document{
	void parse(String str);
	String toMessage();
	Map<String,Object> toMap();
}