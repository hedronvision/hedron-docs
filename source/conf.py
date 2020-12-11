# Configuration file for the Sphinx documentation builder.
#
# This file only contains a few common options. For a full list, see:
# https://www.sphinx-doc.org/en/master/usage/configuration.html

# -- Project information -----------------------------------------------------
# See: https://www.sphinx-doc.org/en/master/usage/configuration.html#project-information

project = 'hedron-docs'
author = "Hedron Vision Incorporated"
copyright = "2020, Hedron Vision Incorporated"
version = '0.0'
release = '0.0.1'


# -- General configuration ---------------------------------------------------
# See: https://www.sphinx-doc.org/en/master/usage/configuration.html#general-configuration

# Names of extension modules, as strings.
# See: https://www.sphinx-doc.org/en/master/usage/configuration.html#confval-extensions
extensions = [
    # Temporarily disable the in-development csharpdomain for rogerbarton's sphinx_csharp.
    # 'sphinxcontrib.csharpdomain',
    'sphinx_csharp',
    'breathe',
    'exhale',
]

# Glob-style patterns to exclude when looking for source files.
# See: https://www.sphinx-doc.org/en/master/usage/configuration.html#confval-exclude_patterns
exclude_patterns = [
    'doxybuild/',
    'Doxyfile',
]

# Our default domain is C#, not Python (the usual default).
# See: https://www.sphinx-doc.org/en/master/usage/configuration.html#confval-primary_domain
primary_domain = 'csharp'

# Minimum acceptable version of Sphinx.
# See: https://www.sphinx-doc.org/en/master/usage/configuration.html#confval-needs_sphinx
needs_sphinx = '3.0'

# Force Sphinx to execute in nitpicky mode.
# See: https://www.sphinx-doc.org/en/master/usage/configuration.html#confval-nitpicky
nitpicky = True

# Tell Sphinx to use the Pygments C# lexer.
# See: https://www.sphinx-doc.org/en/master/usage/configuration.html#confval-highlight_language
# See: https://pygments.org/docs/lexers/#pygments.lexers.dotnet.CSharpLexer
highlight_language = 'csharp'

# Tell Pygments to highlight source code with the solarized theme.
# See: https://www.sphinx-doc.org/en/master/usage/configuration.html#confval-pygments_style
# See: https://pygments.org/docs/styles/
pygments_style = 'solarized-light'


# -- Options for HTML output -------------------------------------------------
# See: https://www.sphinx-doc.org/en/master/usage/configuration.html#options-for-html-output

# The theme for HTML output.
# NOTE: This can be changed to hedron_sphinx_theme once the theme is up on GitHub.
# See: https://www.sphinx-doc.org/en/master/usage/configuration.html#confval-html_theme
html_theme = 'sphinx_rtd_theme'


# -- Options for breathe/exhale ----------------------------------------------
# See: https://breathe.readthedocs.io/en/latest/quickstart.html
# See: https://exhale.readthedocs.io/en/latest/usage.html#quickstart-guide

# Tell breathe where to find doxygen's XML output for each project.
# NOTE: This MUST match the path defined by OUTPUT_DIRECTORY and XML_OUTPUT from
# the Doxyfile used when the doxygen output was built.
# See: https://breathe.readthedocs.io/en/latest/directives.html#confval-breathe_projects
breathe_projects = {
    'hedron-docs': './doxybuild/xml'
}

# Tell breathe which project should be the default for all directives.
# See: https://breathe.readthedocs.io/en/latest/directives.html#confval-breathe_default_project
breathe_default_project = 'hedron-docs'

# Tell breathe to treat *.cs files using the csharp domain.
# Without this option, breathe will silently fail to produce any output, besides
# the object signature. The default mapping associates {'py': 'py', 'cs': 'cs'}.
# That's a pretty good argument for updating the C# domain to support using 'cs'
# as a shorthand for 'csharp', if possible.
# See: https://breathe.readthedocs.io/en/latest/directives.html#confval-breathe_domain_by_extension
breathe_domain_by_extension = {
    'cs': 'cs'
}

# Set up the exhale extension.
# See: https://exhale.readthedocs.io/en/latest/usage.html#setup-the-extensions-in-conf-py
# Note: There are _many_ more available arguments.
exhale_args = {
    # Required Arguments
    'containmentFolder':     './unity-api',
    'rootFileName':          'root.rst',
    'rootFileTitle':         "Unity API Reference",
    'doxygenStripFromPath':  '..',  # This MUST match Doxyfile's STRIP_FROM_PATH.
    # Optional Arguments
    # Ask exhale to run doxygen when `make html` is executed.
    # See: https://exhale.readthedocs.io/en/latest/reference/configs.html#exhale.configs.exhaleExecutesDoxygen
    'exhaleExecutesDoxygen': True,
    # We're currently handling all doxygen configuration with a Doxyfile instead
    # of using 'exhaleDoxygenStdin' (which adds custom tags, such as INPUT) on
    # top of exhale.configs.DEFAULT_DOXYGEN_STDIN_BASE.
    # See: https://exhale.readthedocs.io/en/latest/usage.html#using-exhale-to-execute-doxygen
    # See: https://exhale.readthedocs.io/en/latest/reference/configs.html#exhale.configs.exhaleUseDoxyfile
    'exhaleUseDoxyfile': True
}
