package com.mordent.api.itf.context;

public interface Context{
	/** Global Unique Id */
	String getGlobalUniqueId();
	/** Global Transaction Id */
	String getGlobalTransactionId();
	/** Global Request Id */
	String getGlobalRequestId();
	/** Global Node Id */
	String getGlobalNodeId();
}