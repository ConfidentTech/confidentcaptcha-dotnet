
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG)
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/CaptchaSite.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../CaptchaLib/bin/Debug/CaptchaLib.dll
BUILD_DIR = bin

CAPTCHALIB_DLL_SOURCE=../CaptchaLib/bin/Debug/CaptchaLib.dll
CAPTCHASITE_DLL_MDB_SOURCE=bin/CaptchaSite.dll.mdb
CAPTCHASITE_DLL_MDB=$(BUILD_DIR)/bin/CaptchaSite.dll.mdb
WEB_CONFIG_SOURCE=web.config
DEFAULT_ASPX_SOURCE=Default.aspx
CALLBACK_ASHX_SOURCE=Callback.ashx
MULTIPLE_ASPX_SOURCE=Multiple.aspx
SINGLE_ASPX_SOURCE=Single.aspx

endif

ifeq ($(CONFIG),RELEASE)
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/CaptchaSite.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../CaptchaLib/bin/Release/CaptchaLib.dll
BUILD_DIR = bin

CAPTCHALIB_DLL_SOURCE=../CaptchaLib/bin/Release/CaptchaLib.dll
CAPTCHASITE_DLL_MDB=
WEB_CONFIG_SOURCE=web.config
DEFAULT_ASPX_SOURCE=Default.aspx
CALLBACK_ASHX_SOURCE=Callback.ashx
MULTIPLE_ASPX_SOURCE=Multiple.aspx
SINGLE_ASPX_SOURCE=Single.aspx

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES_BIN = \
	$(CAPTCHALIB_DLL) \
	$(CAPTCHASITE_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(CAPTCHASITE_PC)  

PROGRAMFILES = \
	$(WEB_CONFIG) \
	$(DEFAULT_ASPX) \
	$(CALLBACK_ASHX) \
	$(MULTIPLE_ASPX) \
	$(SINGLE_ASPX)  


RESGEN=resgen2

CAPTCHALIB_DLL = $(BUILD_DIR)/bin/CaptchaLib.dll
CAPTCHASITE_PC = $(BUILD_DIR)/captchasite.pc
WEB_CONFIG = $(BUILD_DIR)/web.config
DEFAULT_ASPX = $(BUILD_DIR)/Default.aspx
CALLBACK_ASHX = $(BUILD_DIR)/Callback.ashx
MULTIPLE_ASPX = $(BUILD_DIR)/Multiple.aspx
SINGLE_ASPX = $(BUILD_DIR)/Single.aspx

FILES = \
	Default.aspx.cs \
	Callback.ashx.cs \
	Multiple.aspx.cs \
	Single.aspx.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	web.config \
	Default.aspx \
	Callback.ashx \
	Multiple.aspx \
	Single.aspx \
	captchasite.pc.in 

REFERENCES =  \
	System \
	System.Web \
	System.Xml \
	System.Web.Services

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES_BIN) $(LINUX_PKGCONFIG) $(PROGRAMFILES) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES_BIN) $(LINUX_PKGCONFIG) $(PROGRAMFILES)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,CAPTCHALIB_DLL))
$(eval $(call emit-deploy-target,CAPTCHASITE_DLL_MDB))
$(eval $(call emit-deploy-wrapper,CAPTCHASITE_PC,captchasite.pc))
$(eval $(call emit-deploy-target,WEB_CONFIG))
$(eval $(call emit-deploy-target,DEFAULT_ASPX))
$(eval $(call emit-deploy-target,CALLBACK_ASHX))
$(eval $(call emit-deploy-target,MULTIPLE_ASPX))
$(eval $(call emit-deploy-target,SINGLE_ASPX))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)/bin'
	$(call cp,$(CAPTCHALIB_DLL),$(DESTDIR)$(libdir)/$(PACKAGE)/bin)
	$(call cp,$(CAPTCHASITE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE)/bin)
	mkdir -p '$(DESTDIR)$(libdir)/pkgconfig'
	$(call cp,$(CAPTCHASITE_PC),$(DESTDIR)$(libdir)/pkgconfig)
	$(call cp,$(WEB_CONFIG),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(DEFAULT_ASPX),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(CALLBACK_ASHX),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(MULTIPLE_ASPX),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(SINGLE_ASPX),$(DESTDIR)$(libdir)/$(PACKAGE))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(CAPTCHALIB_DLL),$(DESTDIR)$(libdir)/$(PACKAGE)/bin)
	$(call rm,$(CAPTCHASITE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE)/bin)
	$(call rm,$(CAPTCHASITE_PC),$(DESTDIR)$(libdir)/pkgconfig)
	$(call rm,$(WEB_CONFIG),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(DEFAULT_ASPX),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(CALLBACK_ASHX),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MULTIPLE_ASPX),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(SINGLE_ASPX),$(DESTDIR)$(libdir)/$(PACKAGE))
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
