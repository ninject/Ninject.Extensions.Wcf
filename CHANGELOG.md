# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [3.3.2]

### Fixed
- The non-singleton service is instantiated unexpectedly during host.

## [3.3.1]

### Fixed
- Dispose the dependencies too early.

## [3.3.0]

### Removed
- Dropped support for older .NET Platform (pre .NET4.5)

## [3.2.2]

### Fixed
- WS-Discovery does not work.

## [3.2.1]

### Changed
- Set `NinjectBehaviorExtensionElement`'s kernel when start

## [3.2.0]

### Added
- Transient scoped services are disposed when not used anymore.
- Endpoints can now be configured in the app config. Rest service and mex bindings can now be used together with NinjectServiceHostFactory. Marked NinjectWebServiceHostFactory obsolete
- Better support for selfhosting
- #21: Close or abort wcf client depending on its state before dispose
- Support WCF behaviors

### Changed
- Transient Services are disposed when not used anymore

## [3.0.0.0]

### Added
- Support for restful services
- Support for data services
- NinjectServiceHost<T> to support creation of self hosted services without having to define ServiceHost bindings
- Support for singleton services hosted on IIS

### Changed
- Wcf IIS hosting is now based on Ninject.Web.Common